namespace ProductsApi.Log
{
    public static class Logs
    {
        public static void AddLog(string error)
        {
            var logFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
            var logFileName = DateTime.Now.ToString();
            logFileName = logFileName.Replace(" ", "_").Replace(":", "-").Replace("/", "-");
            logFileName +=  ".txt";
            var logFile = Path.Combine(logFolder,logFileName);

            DirectoryInfo logDir = new DirectoryInfo(logFolder);
            if(!logDir.Exists)
                logDir.Create();
            FileInfo fileInfo = new FileInfo(logFile);
            var writer = fileInfo.CreateText();
            writer.WriteLine(error);
            writer.Close();
        }
    }
}
