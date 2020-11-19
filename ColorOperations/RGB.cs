using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOperations
{
    /// <summary>
    /// Provides collection of methods to proccessing RGB color mode.
    /// </summary>
    public class RGB
    {
        /// <summary>
        /// Red parameter in RGB mode.
        /// </summary>
        public double R { get; set; }
        /// <summary>
        /// Green parameter in RGB mode.
        /// </summary>
        public double G { get; set; }
        /// <summary>
        /// Blue parameter in RGB mode.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Constructs new RGB color.
        /// </summary>
        public RGB()
        {

        }

        /// <summary>
        /// Constructs new RGB color.
        /// </summary>
        /// <param name="r">Red parameter in RGB mode.</param>
        /// <param name="g">Green parameter in RGB mode.</param>
        /// <param name="b">Blue parameter in RGB mode.</param>
        public RGB(double r, double g, double b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Convert RGB color to the following format: RGB(255, 255, 255).
        /// </summary>
        /// <returns>String RGB color.</returns>
        public string ToUpperRGBString()
        {
            return "RGB(" + R + ", " + G + ", " + B + ")";
        }

        /// <summary>
        /// Convert RGB color to the following format: RGB(255, 255, 255).
        /// </summary>
        /// <returns>String RGB color.</returns>
        public string ToLowerRGBString()
        {
            return "rgb(" + R + ", " + G + ", " + B + ")";
        }
        /// <summary>
        /// Convert RGB color to the following format: 255 255 255.
        /// </summary>
        /// <returns>String RGB color.</returns>
        public string ToSpacesString()
        {
            return R + " " + G + " " + B;
        }
        /// <summary>
        /// Convert RGB color to the following format: 255, 255, 255.
        /// </summary>
        /// <returns>String RGB color.</returns>
        public override string ToString()
        {
            return R + ", " + G + ", " + B;
        }
    }
}
