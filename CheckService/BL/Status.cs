using System.ServiceProcess;
using CheckService.Interfaces;
using CheckService.Models;

namespace CheckService.BL
{
    public class Status : IStatus
    {
        public string ServiceStatus(string servicename)
        {
            ServiceController sc = new ServiceController(servicename);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }

        public string UpdateStatus(StatusRequest statusRequest)
        {
            ServiceController sc = new ServiceController(statusRequest.ServiceName);
            var status = ServiceStatus(statusRequest.ServiceName);
            var result = "";
            if(status == "Running" && statusRequest.Action == "Stop")
            {
                sc.Stop();
                result = "Service stopped successfully.";
            }
            else if (status == "Stopped" && statusRequest.Action == "Start")
            {
                sc.Start();
                result = "Service started successfully.";
            }
            else
            {
                result = "The service is: " + ServiceStatus(statusRequest.ServiceName);
            }
            return result;
        }
    }
}