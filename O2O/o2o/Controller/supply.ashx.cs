﻿using Model;
using o2o.Utils;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace o2o.Controller
{
    /// <summary>
    /// Summary description for supply
    /// </summary>
    public class supply : IHttpHandler
    {
        SupplyService supplyService = new SupplyService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";            
            string action = context.Request["action"].ToString();            
            switch (action)            
            {                
                case "test":AllSupplyList(context);break;                
                default:break;            
            }

        }
        public void AllSupplyList(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<Supply> list = supplyService.getAllSupplyList();
            StringBuilder jsonString = new StringBuilder();
            Dictionary<String, Object> dictionary = new Dictionary<string, object>();
            //jsonString.Append("\"supply\":");
            jsonString.Append("[");
            int i = 1;
            foreach(Supply supply in list){
                dictionary.Add("Id", supply.Id);
                dictionary.Add("supplyName", supply.SupplyName);
                dictionary.Add("supplyDesc",supply.SupplyDesc);
                dictionary.Add("categoryId", supply.SupplyCategory.Id);
                dictionary.Add("priority", supply.Priority);
                dictionary.Add("userId",supply.User.Id);
                dictionary.Add("createTime",supply.CreateTime);
                dictionary.Add("modifyTime", supply.ModifyTime);
                dictionary.Add("supplyStatus", supply.SupplyStatus);
                dictionary.Add("success", "true");
                jsonString.Append(JsonUtil.toJson(dictionary));
                if (i < list.Count) {
                    jsonString.Append(",");
                }
                i++;
                dictionary.Clear();
            }
            jsonString.Append("]");
            context.Response.Write(jsonString.ToString());
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}