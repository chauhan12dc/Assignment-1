using Data_Binding.Models;
using Data_Binding.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Binding.ViewModels
{
    class GenreViewModel
    {
        
        public List<GenreModel> todos { get; set; }
        
        public GenreViewModel()
        {
            todos = new GenreService().GetTodos();
        }

       
    }
}
