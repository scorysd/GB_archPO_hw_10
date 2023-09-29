using System;
namespace ClinicService.Models.Requests
{
	public class UpdatePetRequest
	{		
		public int PetId { get; set; }

        public int ClienId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}


