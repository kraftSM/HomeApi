using FluentValidation;
//using HomeApi.Contracts.Models.Devices;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Contracts.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation
{
    public class EditRoomRequestValidator : AbstractValidator<EditRoomRequest>
    {
        public EditRoomRequestValidator()
        {
            RuleFor(x => x.NewName).NotEmpty().Must(BeSupported)
                .WithMessage($"Please choose one of the following Names: {string.Join(", ", Values.ValidRooms)}"); 
            RuleFor(x => x.NewArea).NotEmpty().GreaterThan(0)
                 .WithMessage($"Room area must be > 0:");
            //RuleFor(x => x.NewGasConnected).NotEmpty(); // If Empty > False
            RuleFor(x => x.NewVoltage).NotEmpty().InclusiveBetween(120, 220)
                .WithMessage($"Room voltage must be 120< Volt< 220:");
        }
        /// <summary>
        ///  Метод кастомной валидации для свойства name
        /// </summary>
        private bool BeSupported(string name)
        {
            // Проверим, содержится ли значение в списке допустимых
            return Values.ValidRooms.Any(e => e == name);
        }
     

    }
}
