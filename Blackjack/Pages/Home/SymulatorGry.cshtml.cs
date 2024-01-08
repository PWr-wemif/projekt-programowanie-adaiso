using Microsoft.AspNetCore.Mvc.RazorPages;
using Blackjack.Models;

namespace Blackjack.Pages.Home
{
    public class SymulatorGryModel : PageModel
    {
        public BlackjackModel Blackjack { get; set; }

        public void OnGet()
        {
            Blackjack = new BlackjackModel();
            Blackjack.InicjalizujTalie();
            Blackjack.RozdajKarty();
        }

        public void OnPostDobierzKarte()
        {
            InicjalizujBlackjack();
            Blackjack.DobierzKarte();
        }

        public void OnPostStand()
        {
            InicjalizujBlackjack();
            Blackjack.Stand();
        }

        private void InicjalizujBlackjack()
        {
            if (Blackjack == null)
            {
                Blackjack = new BlackjackModel();
                Blackjack.InicjalizujTalie();
                Blackjack.RozdajKarty();
            }
        }
    }
}
