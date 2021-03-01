using Data_Binding.Models;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
namespace Data_Binding.Services
{
    class GenreService
    {
        List<GenreModel> genreModelList = new List<GenreModel>();
        
        public GenreService()
        {
            List<String> selectedGenre = new List<string>(Preferences.Get("selectedGenre", "false").Split(','));
            
            foreach (String item in selectedGenre)
            {
                GenreModel todoModel = new GenreModel();
                todoModel.todo = item;
                genreModelList.Add(todoModel);
            }
        }
        
        public List<GenreModel> GetTodos()
        {
            return genreModelList;
        }
       
    }
}
