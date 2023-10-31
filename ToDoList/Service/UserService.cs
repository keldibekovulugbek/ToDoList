using ToDoList.Brokers;
using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericBroker<User> _broker;
        private readonly IFileService _fileService;

        public UserService(IGenericBroker<User> broker, IFileService fileService)
        {
            _broker = broker;
            _fileService = fileService;
        }

        public bool IsExist(User user)
        {
            var existUser = _broker.Get().Result.FirstOrDefault(x => x.Email.Equals(user.Email));
           
            if (existUser is null)
                return false;

            return true;
        }

        public async ValueTask<User> CreateAsync(User user, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {   
            if (IsExist(user))
                throw new Exception("This user is exist");

            var entity = await _broker.CreateAsync(user);

            return entity;
        }

        public async ValueTask<bool> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            var user = await _broker.GetByIdAsync(id);

           return await _broker.DeleteAsync(user);
        }

        public async ValueTask<IEnumerable<User>> Get(CancellationToken cancellationToken = default)
            => _broker.Get().Result.AsEnumerable<User>();


        public ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => _broker.GetByIdAsync(id);

        public async ValueTask<User> UpdateAsync(Guid id, User user, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            var model = await _broker.UpdateAsync(user);

            return model;
        }

        public async ValueTask<User> UploadImageAsync(Guid id, UploadImageDTO imageDTO, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            var user = await _broker.GetByIdAsync(id);

            await _fileService.DeleteAsync(user.ImagePath);

            user.ImagePath = await _fileService.SaveImageAsync(imageDTO.Image);

            await _broker.UpdateAsync(user);
            
            return user;
        }
    }
}
