﻿using Glimpse.Web;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Glimpse.Agent.Browser.Resources
{
    public class BrowserAgent : IRequestHandler
    {
        public bool WillHandle(IHttpContext context)
        {
            return context.Request.Path == "/Glimpse/Browser/Agent";
        }

        public async Task Handle(IHttpContext context)
        {
            var response = context.Response;

            response.SetHeader("Content-Type", "application/javascript");

            var assembly = typeof(BrowserAgent).GetTypeInfo().Assembly;

            var jqueryStream = assembly.GetManifestResourceStream("Resources/Embed/scripts/jquery/jquery-2.1.1.js");
            var signalrStream = assembly.GetManifestResourceStream("Resources/Embed/scripts/signalr/jquery.signalR-2.2.0.js");
            var agentStream = assembly.GetManifestResourceStream("Resources/Embed/scripts/BrowserAgent.js");

            using (var jqueryReader = new StreamReader(jqueryStream, Encoding.UTF8))
            using (var signalrReader = new StreamReader(signalrStream, Encoding.UTF8))
            using (var agentReader = new StreamReader(agentStream, Encoding.UTF8))
            {
                // TODO: The worlds worst hack!!! Nik did this...
                await response.WriteAsync(jqueryReader.ReadToEnd() + signalrReader.ReadToEnd() + agentReader.ReadToEnd());
            } 
        }
    }
}