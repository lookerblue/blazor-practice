using System;
using System.ComponentModel.DataAnnotations;
using static BlazorPractice.Shared.ComponentEnums;

namespace BlazorPractice.Shared
{
    public class Starship2
    {
        [Required]
        [Range(typeof(Manufacturer), nameof(Manufacturer.SpaceX), nameof(Manufacturer.VirginGalactic), ErrorMessage = "Pick a manufacturer.")]
        public Manufacturer Manufacturer { get; set; } = Manufacturer.Unknown;

        [Required, EnumDataType(typeof(Color))]
        public Color? Color { get; set; } = null;

        [Required, EnumDataType(typeof(Engine))]
        public Engine? Engine { get; set; } = null;
    }
}
