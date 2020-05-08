using System.Security.Cryptography.X509Certificates;

namespace App.Service
{
    public class OperationResult
    {
        public OperationResult()
        {
            

        }
        public string Text { get; set; }
        public object ReturnedObject { get; set; }
        public severity_num severity { get; set; }

    }
    public enum severity_num
    {
        success=1,
        warning=2,
        error=3
    }
}