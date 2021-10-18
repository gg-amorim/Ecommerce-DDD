using Domain.Interfaces.Generics;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infra.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<BaseContext> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<BaseContext>();
        }

        public async Task Add(T Obj)
        {
            using (var data = new BaseContext(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(Obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Obj)
        {
            using (var data = new BaseContext(_OptionsBuilder))
            {
                data.Set<T>().Remove(Obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(int Id)
        {
            using (var data = new BaseContext(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new BaseContext(_OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T Obj)
        {
            using (var data = new BaseContext(_OptionsBuilder))
            {
                data.Set<T>().Update(Obj);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed

        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }

        #endregion Disposed
    }
}