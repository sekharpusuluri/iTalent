#r "System.Configuration"
#r "System.Data"
#r "System.Net"
#r "Newtonsoft.Json"
#r "iTalent.LithiumConnector.dll"

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using iTalent.LithiumConnector;
using System.Configuration;

/* Copyright (c) 2018 iTalent Digital */
public static void Run(TimerInfo myTimer, TraceWriter log)
{
     string strTenantID = ConfigurationManager.AppSettings["LithiumTenantId"] != null ? ConfigurationManager.AppSettings["LithiumTenantId"].ToString() : string.Empty;
            string strClientID = ConfigurationManager.AppSettings["LithiumClientId"] != null ? ConfigurationManager.AppSettings["LithiumClientId"].ToString() : string.Empty;
            string strClientSecret = ConfigurationManager.AppSettings["LithiumClientSecret"] != null ? ConfigurationManager.AppSettings["LithiumClientSecret"].ToString() : string.Empty;
            string strRefreshToken = ConfigurationManager.AppSettings["LithiumRefreshToken"] != null ? ConfigurationManager.AppSettings["LithiumRefreshToken"].ToString() : string.Empty;
            string strSQLConn = ConfigurationManager.AppSettings["SqlConnectionString"] != null ? ConfigurationManager.AppSettings["SqlConnectionString"].ToString() : string.Empty;

     if (strSQLConn != string.Empty && strTenantID != string.Empty && strClientID != string.Empty && strClientSecret != string.Empty && strRefreshToken != string.Empty)
     {
         log.Info($"Starting the Lithium ETL execution at: {DateTime.Now.ToString()}");
         new GetLithiumData(log).LoadandProcessLithiumData(strSQLConn, strTenantID, strClientID, strClientSecret, strRefreshToken);
         log.Info($"Completed the Lithium ETL execution at: {DateTime.Now} .");
     }
}
