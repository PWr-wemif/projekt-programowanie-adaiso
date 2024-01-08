using System.ComponentModel.DataAnnotations;

namespace Blackjack.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Nick { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
