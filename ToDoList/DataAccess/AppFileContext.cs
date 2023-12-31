﻿using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using ToDoList.Entities;
using ToDoList.Entities.Common;

namespace ToDoList.Data
{
    public class AppFileContext : FileContext, IDataContext
    {
        public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));
        public IFileSet<ToDo, Guid> ToDos => Set<ToDo, Guid>(nameof(ToDos));

        public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
        {
            OnSaveChanges += AddPrimaryKeys;
        }

        public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
        {
            foreach (var fileSet in fileSets)
                foreach (var entry in fileSet.GetEntries())
                {
                    if (entry is not IFileEntityEntry<IEntity> entityEntry) continue;

                    if (entityEntry.State == FileEntityState.Added)
                        entityEntry.Entity.Id = Guid.NewGuid();

                    if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
                }

            return new ValueTask(Task.CompletedTask);
        }

    }
}
