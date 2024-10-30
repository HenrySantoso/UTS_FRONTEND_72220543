using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorAppSolution.UI.Model; // Adjust the namespace according to your project structure

namespace BlazorAppSolution.UI.Services
{
    public class CourseService
    {
        private readonly HttpClient _httpClient;
        private const string CourseApiUrl = "https://actualbackendapp.azurewebsites.net/api/Courses";
        private const string CategoryApiUrl = "https://actualbackendapp.azurewebsites.net/api/v1/Categories"; // New API URL for categories

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all courses
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>(CourseApiUrl);
        }

        // Get a course by ID
        public async Task<Course> GetCourseAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Course>($"{CourseApiUrl}/{id}");
        }

        // Create a new course
        public async Task<Course> CreateCourseAsync(Course course)
        {
            var response = await _httpClient.PostAsJsonAsync(CourseApiUrl, course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Course>();
        }

        // Update an existing course
        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            var response = await _httpClient.PutAsJsonAsync($"{CourseApiUrl}/{id}", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Course>();
        }

        // Delete a course
        public async Task DeleteCourseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{CourseApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

        // New method to get all categories
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>(CategoryApiUrl); // Fetch categories from the new API URL
        }
    }
}
