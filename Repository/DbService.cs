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
            _context.Songs.Remove(_context.Songs.Find(id));
            _context.SaveChanges();
        }

        public IQueryable<Song> FindAll(Expression<Func<Song, bool>> predicate)
        {
            return _context.Songs.Where(predicate);
        }

        public Song Get(int id)
        {
            return _context.Songs.Find(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
