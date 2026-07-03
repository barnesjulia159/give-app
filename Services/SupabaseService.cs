using Supabase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Capstone.Services
{
    public class SupabaseService
    {
        private readonly Client _client;
        private readonly IConfiguration _configuration;

        public SupabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration["Supabase:Url"] ?? throw new InvalidOperationException("Supabase URL not configured");
            var key = _configuration["Supabase:Key"] ?? throw new InvalidOperationException("Supabase Key not configured");

            _client = new Client(url, key);
        }

        public async Task InitializeAsync()
        {
            try
            {
                await _client.InitializeAsync();
                Console.WriteLine("✅ Supabase client initialized successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to initialize Supabase client: {ex.Message}");
                throw;
            }
        }

        // Example: Get all records from a table
        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            try
            {
                var response = await _client.From<T>().Get();
                return response.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching data: {ex.Message}");
                throw;
            }
        }

        // Example: Insert a new record
        public async Task InsertAsync<T>(T item) where T : class
        {
            try
            {
                await _client.From<T>().Insert(item);
                Console.WriteLine($"✅ Record inserted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inserting record: {ex.Message}");
                throw;
            }
        }

        // Update a record
        public async Task UpdateAsync<T>(T item) where T : class
        {
            try
            {
                await _client.From<T>().Update(item);
                Console.WriteLine($"✅ Record updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating record: {ex.Message}");
                throw;
            }
        }

        // Delete a record
        public async Task DeleteAsync<T>(string id) where T : class
        {
            try
            {
                await _client.From<T>().Delete(id);
                Console.WriteLine($"✅ Record deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting record: {ex.Message}");
                throw;
            }
        }

        public Client Client => _client;
    }
}