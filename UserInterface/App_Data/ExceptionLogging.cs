using System;
using System.IO;
using context = System.Web.HttpContext;

/// <summary>
/// Summary description for ExceptionLogging
/// </summary>
/// 
namespace UserInterface.App_data
{

    public interface IExceptionLogging
    {
        void SendErrorToText(Exception ex);


    }


    //singletone design pattern for execption logging
public sealed class ExceptionLogging: IExceptionLogging
    {
        private ExceptionLogging()
        {
            //make this constructor as private so it will not be accesible to out side
        }
        // private static readonly Lazy<ExceptionLogging> instance = new Lazy<ExceptionLogging>();
        private static readonly Lazy<ExceptionLogging> _Instance = new Lazy<ExceptionLogging>(() => new ExceptionLogging());
        public static ExceptionLogging GetInstant
        {
            get {
                return _Instance.Value;
            } 
        }
        private static String ErrorlineNo, InnerException, Errormsg, extype, exurl, hostIp, ErrorLocation, HostAdd;

    public  void SendErrorToText(Exception ex)
    {
        var line = Environment.NewLine + Environment.NewLine;

        ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 4, 4);
            if (ex.InnerException !=null)
            {
                InnerException = ex.InnerException.ToString();
            }
       

        Errormsg = ex.GetType().Name.ToString();
        extype = ex.GetType().ToString();
        exurl = context.Current.Request.Url.ToString();
        ErrorLocation = ex.Message.ToString();

        try
        {
            string filepath = context.Current.Server.MapPath("~/ExceptionDetailsFile/");  //Text File Path

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(filepath))
            {
                string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + exurl + line + "User Host IP:" + " " + hostIp + line+ "Inner Exception" + " "+ InnerException;
                sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine(line);
                sw.WriteLine(error);
                sw.WriteLine("--------------------------------*End*------------------------------------------");
                sw.WriteLine(line);
                sw.Flush();
                sw.Close();
            }
        }
        catch (Exception e)
        {
            e.ToString();
        }
    }

    public static void SendText(string ex)
    {
        var line = Environment.NewLine + Environment.NewLine;

        try
        {
            string filepath = context.Current.Server.MapPath("~/maildetails/");  //Text File Path

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(filepath))
            {
                string error = ex;
                sw.WriteLine("-----------Mail Details on " + " " + DateTime.Now.ToString() + "-----------------");
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine(line);
                sw.WriteLine(error);
                sw.WriteLine("--------------------------------*End*------------------------------------------");
                sw.WriteLine(line);
                sw.Flush();
                sw.Close();
            }
        }
        catch (Exception e)
        {
            e.ToString();
        }
    }
}

}
