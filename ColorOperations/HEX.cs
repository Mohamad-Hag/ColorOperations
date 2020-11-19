using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOperations
{
    /// <summary>
    /// Provides collection of methods to proccessing Hex color mode.
    /// </summary>
    public class HEX
    {
        /// <summary>
        /// Red part in Hex mode.
        /// </summary>
        public string R { get; set; }
        /// <summary>
        /// Green part in Hex mode.
        /// </summary>
        public string G { get; set; }
        /// <summary>
        /// Blue part in Hex mode.
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// Constructs new Hex color.
        /// </summary>
        public HEX()
        {

        }

        /// <summary>
        /// Constructs new Hex color.
        /// </summary>
        /// <param name="r">Red part in Hex mode.</param>
        /// <param name="g">Green part in Hex mode.</param>
        /// <param name="b">Blue part in Hex mode.</param>
        public HEX(string r, string g, string b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Convert Hex color to the following format: #FFFFFF.
        /// </summary>
        /// <returns>String Hex color.</returns>
        public string ToHashString()
        {
            return "#" + R + G + B;
        }
        /// <summary>
        /// Convert Hex color to the following format: FFFFFF.
        /// </summary>
        /// <returns>String Hex color.</returns>
        public override string ToString()
        {
            return R + G + B;
        }
    }
}
