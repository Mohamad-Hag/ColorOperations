using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOperations
{
    /// <summary>
    /// Provides collection of methods to proccessing HSL color mode.
    /// </summary>
    public class HSL
    {
        /// <summary>
        /// Hue parameter in HSL mode.
        /// </summary>
        public double H { get; set; }
        /// <summary>
        /// Saturation parameter in HSL mode.
        /// </summary>
        public double S { get; set; }
        /// <summary>
        /// Lightness (Luminance) parameter in HSL mode.
        /// </summary>
        public double L { get; set; }

        /// <summary>
        /// Constructs new HSL color.
        /// </summary>
        public HSL()
        {

        }

        /// <summary>
        /// Constructs new HSL color.
        /// </summary>
        /// <param name="h">Hue parameter in HSL mode.</param>
        /// <param name="s">Saturation parameter in HSL mode.</param>
        /// <param name="l">Lightness (Luminance) parameter in HSL mode.</param>
        public HSL(double h, double s, double l)
        {
            this.H = h;
            this.S = s;
            this.L = l;
        }

        /// <summary>
        /// Convert HSL color to the following format: HSL(360, 100, 100).
        /// </summary>
        /// <returns>String RGB color.</returns>
        public string ToUpperHSLString()
        {
            return "HSL(" + H + ", " + S + ", " + L + ")";
        }

        /// <summary>
        /// Convert HSL color to the following format: hsl(360, 100, 100).
        /// </summary>
        /// <returns>String HSL color.</returns>
        public string ToLowerHSLString()
        {
            return "hsl(" + H + ", " + S + ", " + L + ")";
        }

        /// <summary>
        /// Convert HSL color to the following format: 360 100 100.
        /// </summary>
        /// <returns>String RGB color.</returns>
        public string ToSpacesString()
        {
            return H + " " + S + " " + L;
        }

        /// <summary>
        /// Convert HSL color to the following format: 360, 100, 100.
        /// </summary>
        /// <returns>String HSL color.</returns>
        public override string ToString()
        {
            return H + ", " + S + ", " + L;
        }
    }
}
