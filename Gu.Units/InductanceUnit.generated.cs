﻿namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.InductanceUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Henrys.symbol}")]
    public struct InductanceUnit : IUnit, IUnit<Inductance>, IEquatable<InductanceUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Henrys"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Henrys = new InductanceUnit(1.0, "H");
        /// <summary>
        /// The <see cref="T:Gu.Units.Henrys"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly InductanceUnit H = Henrys;

        private readonly double conversionFactor;
        private readonly string symbol;

        public InductanceUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Henrys"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Inductance operator *(double left, InductanceUnit right)
        {
            return Inductance.From(left, right);
        }

        public static bool operator ==(InductanceUnit left, InductanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InductanceUnit left, InductanceUnit right)
        {
            return !left.Equals(right);
        }

        public static InductanceUnit Parse(string text)
        {
            return Parser.ParseUnit<InductanceUnit>(text);
        }

        public static bool TryParse(string text, out InductanceUnit value)
        {
            return Parser.TryParseUnit<InductanceUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Henrys"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Henrys.
        /// </summary>
        /// <param name="value">The value in Henrys</param>
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
        public Inductance CreateQuantity(double value)
        {
            return new Inductance(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Inductance quantity)
        {
            return FromSiUnit(quantity.henrys);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(InductanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is InductanceUnit && Equals((InductanceUnit)obj);
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