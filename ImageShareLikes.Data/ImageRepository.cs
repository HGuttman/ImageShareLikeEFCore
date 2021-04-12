using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageShareLikes.Data
{
    public class ImageRepository
    {
        private readonly string _connectionString;
        public ImageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Image> GetImages()
        {
            using var context = new ImageDBContext(_connectionString);
            return context.Images.OrderByDescending(i => i.Date).ToList();
        }
        public void AddImage(Image image)
        {
            using var context = new ImageDBContext(_connectionString);
            context.Images.Add(image);
            context.SaveChanges();
        }
        public Image GetImageById(int id)
        {
            using var context = new ImageDBContext(_connectionString);
            return context.Images.FirstOrDefault(i => id == i.Id);
        }
        public void Update(int id)
        {
            using var context = new ImageDBContext(_connectionString);
            var image = GetImageById(id);
            image.Likes += 1;
            context.Images.Attach(image);
            context.Entry(image).State = EntityState.Modified;
            context.SaveChanges();
        }
        public int GetImageLikes(int id)
        {
            using var context = new ImageDBContext(_connectionString);
            var image = GetImageById(id);
            return image.Likes;
        }
    }
}
