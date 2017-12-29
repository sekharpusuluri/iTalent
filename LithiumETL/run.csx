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
    log.Info($"Starting the GetLithiumData function execution at: {DateTime.Now.ToString()}");

    string strTenantID = ConfigurationManager.ConnectionStrings["LithiumTenantId"].ToString();
    string strClientID = ConfigurationManager.ConnectionStrings["LithiumClientId"].ToString();
    string strClientSecret = ConfigurationManager.ConnectionStrings["LithiumClientSecret"].ToString();
    string strRefreshToken = ConfigurationManager.ConnectionStrings["LithiumRefreshToken"].ToString();
            
    string strSQLConn = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();

    GetLithiumData getLithiumData = new GetLithiumData(log);
    getLithiumData.LoadandProcessLithiumData(strSQLConn, strTenantID, strClientID, strClientSecret, strRefreshToken);

    log.Info($"Completed the GetLithiumData function execution at: {DateTime.Now} .");
}
