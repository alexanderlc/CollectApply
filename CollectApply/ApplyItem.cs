using System;
using System.Collections.Generic;
using System.Text;

namespace CollectApply
{
    class ApplyItem
    {
        private String mFrom;
        private String mFromEmail;

        public String FromEmail
        {
            get { return mFromEmail; }
            set { mFromEmail = value; }
        }
        public String From
        {
            get { return mFrom; }
            set { mFrom = value; }
        }
        private String mTitle;

        public String Title
        {
            get { return mTitle; }
            set { mTitle = value; }
        }
      
        private String mTime;

        public String Time
        {
            get {
                DateTime dt = DateTime.Parse(mTime);
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
            set { mTime = value; }
        }
        public String getDate()
        {
            DateTime dt = DateTime.Parse(mTime);
            return dt.ToString("yyyy-MM-dd");
        }
        private Dictionary<String, String> map = new Dictionary<String, String>();
        public void addKeyValue(String key, String value)
        {
            map.Add(key, value);
        }
        public String getValue(String key)
        {
            return map[key];
        }
        public override String ToString()
        {
            String res = "From=" + mFrom + "; \n\rDate="+getDate();
            foreach (KeyValuePair<String, String> item in map)
            {
                res = res + item.Key + "=" + item.Value + "; \n\r";
            }
            return res;
        }
        //"企业名称:",
        //"所在省份:",
        //"所在城市:",
        //"企业地址:",
        //"法人代表:",
        //"企业成立日期:",
        //"企业联系人:",
        //"联系人职务:",
        //"联系电话:",
        //"手机号码:",
        //"职工人员:",
        //"所属行业:",
        //"主业从业年限:",
        //"去年销售收入:",
        //"主导产品、品牌及生产能力:",
        //"申请融资金额:",
        //"申请融资产品:",
        //"申请融资期限:",
        //"申请融资原因:",
        //"可提供担保方式:"
    }
}
