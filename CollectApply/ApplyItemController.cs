using System;
using System.Collections.Generic;
using System.Text;

namespace CollectApply
{
    class ApplyItemController
    {
        public static ApplyItem getApplyItem(OpenPOP.MIMEParser.Message m)
        {

            if (m.Subject.Contains("在线融资申请") && m.MessageBody.Count > 0)
            {
                String body = m.MessageBody[m.MessageBody.Count - 1].ToString();
                if (m.HTML)
                {
                    ApplyItem item = new ApplyItem();
                    String text = Utils.Tools.prepareHTML(body);
                    string[] sub = text.Split(new String[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sub.Length % 2 != 0 || sub.Length == 0)
                    {
                        return null;
                    }
                    for (int i = 0; i < sub.Length; i = i + 2)
                    {
                        item.addKeyValue(sub[i], sub[i + 1]);
                    }
                    item.Time = m.Date;
                    item.From = m.From;
                    item.Title = m.Subject;
                    item.FromEmail = m.FromEmail;
                    return item;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
