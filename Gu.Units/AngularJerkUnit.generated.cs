﻿namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AngularJerkUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{RadiansPerSecondCubed.symbol}")]
    public struct AngularJerkUnit : IUnit, IUnit<AngularJerk>, IEquatable<AngularJerkUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSecondCubed"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerSecondCubed = new AngularJerkUnit(1.0, "rad/s³");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerSecondCubed"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit DegreesPerSecondCubed = new AngularJerkUnit(0.017453292519943295, "°⋅s⁻³");

        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerHourCubed"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerHourCubed = new AngularJerkUnit(2.1433470507544583E-11, "rad⋅h⁻³");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerHourCubed"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit DegreesPerHourCubed = new AngularJerkUnit(3.7408463048575307E-13, "°⋅h⁻³");

        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerMinuteCubed"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerMinuteCubed = new AngularJerkUnit(4.6296296296296296E-06, "rad⋅min⁻³");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerMinuteCubed"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit DegreesPerMinuteCubed = new AngularJerkUnit(8.0802280184922666E-08, "°⋅min⁻³");

        private readonly double conversionFactor;
        private readonly string symbol;

        public AngularJerkUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.RadiansPerSecondCubed"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static AngularJerk operator *(double left, AngularJerkUnit right)
        {
            return AngularJerk.From(left, right);
        }

        public static bool operator ==(AngularJerkUnit left, AngularJerkUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AngularJerkUnit left, AngularJerkUnit right)
        {
            return !left.Equals(right);
        }

        public static AngularJerkUnit Parse(string text)
        {
            return Parser.ParseUnit<AngularJerkUnit>(text);
        }

        public static bool TryParse(string text, out AngularJerkUnit value)
        {
            return Parser.TryParseUnit<AngularJerkUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.RadiansPerSecondCubed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from RadiansPerSecondCubed.
        /// </summary>
        /// <param name="value">The value in RadiansPerSecondCubed</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public AngularJerk CreateQuantity(double value)
        {
            return new AngularJerk(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AngularJerk quantity)
        {
            return FromSiUnit(quantity.radiansPerSecondCubed);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AngularJerkUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularJerkUnit && Equals((AngularJerkUnit)obj);
        }

        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}