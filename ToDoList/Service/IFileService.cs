namespace ToDoList.Service
{
    public interface IFileService :IDisposable
    {
        string FolderName { get; }

        ValueTask<string> SaveImageAsync(IFormFile image);
        ValueTask<bool> DeleteAsync(string imageName);
    }
}
