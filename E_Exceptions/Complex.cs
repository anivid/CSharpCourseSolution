using System;
using System.Collections.Generic;
using System.Text;

namespace E_Filestream_and_Exceptions
{
    public class Complex
    {
        public double Imaginary { get; private set; }
        public double Real { get; private set; }

        public string ComplexNum { get; private set;}

        public Complex(double realPart, double imgPart)
        {
            //this._realPart = realPart;
            //this._imgPart = imgPart;
            Imaginary = imgPart;
            Real = realPart;
            ComplexNum = $"{Real} + i*{Imaginary}";
        }

        public Complex Plus(Complex c)
        {
            return new Complex(this.Real + c.Real, this.Imaginary + c.Imaginary);
        }
        public Complex Minus(Complex c)
        {
            return new Complex(this.Real - c.Real, this.Imaginary - c.Imaginary);
        }
        
    }
}
