using Slider5.Models;
using Slider5.Repository.IApplication;
using System;
using System.Linq;
using System.Linq.Expressions;
using Slider5.Models.Context;

namespace Slider5.Repository
{
    public class DbService : IDbServices<Song>, IDisposable
    {
        private SliderContext _context;
        public DbService(SliderContext context)
        {
            _context = context;
        }

        public void Add(Song entity)
        {
            _context.Songs.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Song Find(Expression<Func<Song, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Song> FindAll(Expression<Func<Song, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Song Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
