﻿using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Slider.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.OrderByDescending(m=>m.Id).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
           return await _context.Categories.CountAsync();
        }

        public async Task<List<Category>> GetPaginatedDatas(int page,int take)
        {
            return await _context.Categories.Skip((page*take)-take).Take(take).ToListAsync();
        }
    }
}
