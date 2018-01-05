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
     string strTenantID = ConfigurationManager.ConnectionStrings["LithiumTenantId"] != null ? ConfigurationManager.ConnectionStrings["LithiumTenantId"].ToString() : string.Empty;
     string strClientID = ConfigurationManager.ConnectionStrings["LithiumClientId"] != null ? ConfigurationManager.ConnectionStrings["LithiumClientId"].ToString() : string.Empty;
     string strClientSecret = ConfigurationManager.ConnectionStrings["LithiumClientSecret"] != null ? ConfigurationManager.ConnectionStrings["LithiumClientSecret"].ToString() : string.Empty;
     string strRefreshToken = ConfigurationManager.ConnectionStrings["LithiumRefreshToken"] != null ? ConfigurationManager.ConnectionStrings["LithiumRefreshToken"].ToString() : string.Empty;
     string strSQLConn = ConfigurationManager.ConnectionStrings["SqlConnectionString"] != null ? ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString() : string.Empty;

     if (strSQLConn != string.Empty && strTenantID != string.Empty && strClientID != string.Empty && strClientSecret != string.Empty && strRefreshToken != string.Empty)
     {
         log.Info($"Starting the Lithium ETL execution at: {DateTime.Now.ToString()}");
         new GetLithiumData(log).LoadandProcessLithiumData(strSQLConn, strTenantID, strClientID, strClientSecret, strRefreshToken);
         log.Info($"Completed the Lithium ETL execution at: {DateTime.Now} .");
     }
}
