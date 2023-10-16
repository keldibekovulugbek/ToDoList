namespace ToDoList.Service
{
    public interface IFileService
    {
        string FolderName { get; }

        ValueTask<string> SaveImageAsync(IFormFile image);
        ValueTask<bool> DeleteAsync(string imageName);
    }
}
