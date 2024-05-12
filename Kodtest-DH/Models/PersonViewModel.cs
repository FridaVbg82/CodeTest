using System.ComponentModel;

namespace Kodtest_DH.Models
{
    public class PersonViewModel
    {
        public PersonViewModel(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public PersonViewModel(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public PersonViewModel()
        {
        }

        public int Id { get; private set; }

        [DisplayName("Namn")]
        public string Name { get; private set; }

        [DisplayName("Telefon")]
        public string PhoneNumber { get; private set; }
    }
}
