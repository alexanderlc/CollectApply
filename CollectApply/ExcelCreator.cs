using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace CollectApply
{
    class ExcelCreator
    {
        private Excel.Application xlApp;
        private Excel.Workbook xlBook;
        private Excel.Workbooks xlBooks;
        private Excel.Range xlRange;
        private Excel.Sheets xlsheets;
        private Excel.Worksheet xlSheet;

        public ExcelCreator()
        {
            xlApp = new Excel.Application();
        }
        public Boolean toExcel(List<ApplyItem> list, String path)
        {
            try
            {
                xlBooks = xlApp.Workbooks;
                xlBook = xlBooks.Add(Missing.Value);
                xlsheets = xlBook.Worksheets;
                xlSheet = (Excel.Worksheet)xlsheets.get_Item(1);
                xlApp.DisplayAlerts = false;
                string[] keys = new String[] { 
                            "企业名称",
                            "所在省份",
                            "所在城市",
                            "企业地址",
                            "法人代表",
                            "企业成立日期",
                            "企业联系人",
                            "联系人职务",
                            "联系电话",
                            "手机号码",
                            "职工人员",
                            "所属行业",
                            "主业从业年限",
                            "去年销售收入",
                            "主导产品、品牌及生产能力",
                            "申请融资金额",
                            "申请融资产品",
                            "申请融资期限",
                            "申请融资原因",
                            "可提供担保方式"
                        };
                xlSheet.Cells[1, 1] = "申请人";
                xlSheet.Cells[1, 2] = "申请邮箱";
                xlSheet.Cells[1, 3] = "标题";
                xlSheet.Cells[1, 4] = "时间";
                int pos = 5;
                for (int i = 0; i < keys.Length; i++)
                {
                    xlSheet.Cells[1, i + pos] = keys[i];
                }
                for (int i_item = 0; i_item < list.Count; i_item++)
                {
                    ApplyItem item = list[i_item];
                    xlSheet.Cells[i_item + 2, 1] = item.From;
                    xlSheet.Cells[i_item + 2, 2] = item.FromEmail;
                    xlSheet.Cells[i_item + 2, 3] = item.Title;
                    xlSheet.Cells[i_item + 2, 4] = item.Time;
                    for (int i_key = 0; i_key < keys.Length; i_key++)
                    {
                        try
                        {
                            xlSheet.Cells[i_item + 2, i_key + pos] = item.getValue(keys[i_key]);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
                xlBook.Saved = true;
                xlBook.SaveAs(path, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value);
                xlBook.Close(false, Missing.Value, Missing.Value);
            }
            catch (Exception e)
            {
            }
            return true;
        }

    }
}
