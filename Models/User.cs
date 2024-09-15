﻿using System.ComponentModel.DataAnnotations;

namespace Task_MVC.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password {  get; set; }
        public bool IsActive { get; set; } = false;

    }
}
