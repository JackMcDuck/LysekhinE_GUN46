namespace FinalTask.Saving
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _path;

        public FileSystemSaveLoadService(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path can't be empty");
            }
            _path = path;
        }

        public void SaveData(string data, string id)
        {
            try
            {
                CheckDirectoryExist();
                File.WriteAllText(GetFilePath(id), data);
            }
            catch (Exception exception) when (IsFileSystemException(exception))
            {
                Console.WriteLine($"Failed to save data {id} : {exception.Message}");
            }
        }

        public string LoadData(string id)
        {
            try
            {
                CheckDirectoryExist();
                string filePath = GetFilePath(id);
                return File.Exists(filePath) ? File.ReadAllText(filePath) : null;
            }
            catch (Exception exception) when (IsFileSystemException(exception))
            {
                Console.WriteLine($"Failed to load data {id} : {exception.Message}");
                return null;
            }
        }

        private void CheckDirectoryExist()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        private string GetFilePath(string id)
        {
            return Path.Combine(_path, id);
        }

        private bool IsFileSystemException(Exception exception)
        {
            return exception is IOException
                || exception is UnauthorizedAccessException
                || exception is ArgumentException
                || exception is NotSupportedException;
        }
    }
}