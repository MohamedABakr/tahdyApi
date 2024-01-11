using System.ComponentModel.DataAnnotations;
namespace test_Api.Models
{
    public class items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Club { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public bool? Old { get; set; }
        public bool? global { get; set; }

    }
}
