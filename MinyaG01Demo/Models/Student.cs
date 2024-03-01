using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinyaG01Demo.Models
{


//    Student
//    Id, Name, Address, Phone, Age
//ApiController
//"GetAll GetById / GetByName / Update / Add/Delete"
    public class Student
    {
        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(25,ErrorMessage ="Length must be less than 6 Char.")]
        public string Name { get; set; }
        public string Address { get; set; }
        [MinLength(11)]
        [MaxLength(15, ErrorMessage = "Length must be less than 10 Char.")]
        public string Phone { get; set; }
        public int Age { get; set; }

    }
}
