# Gu.Units.
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/JohanLarsson/Gu.Units?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet](https://img.shields.io/nuget/v/Gu.Units.svg)](https://www.nuget.org/packages/Gu.Units/)
[![Build status](https://ci.appveyor.com/api/projects/status/oa2o8euq95v12qi7?svg=true)](https://ci.appveyor.com/project/JohanLarsson/gu-units)

## Contents.

  - [Quantity types.](#quantity-types)
  - [Arithmetic.](#arithmetic)
  - [Conversion.](#conversion)
  - [Formatting.](#formatting)
  - [Parsing.](#parsing)
  - [WPF.](#wpf)
    - [ValueFormat](#valueformat)
    - [SymbolFormat](#symbolformat)
    - [SymbolFormat](#symbolformat)
  - [JSON.](#json)
  - [Code generation when adding new quantities.](#code-generation-when-adding-new-quantities)

## Quantity types.

 - Acceleration
 - AmountOfSubstance
 - Angle
 - AnglePerUnitless
 - AngularAcceleration
 - AngularJerk
 - AngularSpeed
 - Area
 - AreaDensity
 - Capacitance
 - CatalyticActivity
 - Current
 - Data
 - Density
 - ElectricalConductance
 - ElectricCharge
 - Energy
 - Flexibility
 - Force
 - ForcePerUnitless
 - Frequency
 - Illuminance
 - Inductance
 - Jerk
 - KinematicViscosity
 - Length
 - LengthPerUnitless
 - LuminousFlux
 - LuminousIntensity
 - MagneticFieldStrength
 - MagneticFlux
 - Mass
 - MassFlow
 - Momentum
 - Power
 - Pressure
 - Resistance
 - SolidAngle
 - SpecificEnergy
 - SpecificVolume
 - Speed
 - Stiffness
 - Temperature
 - Time
 - Torque
 - Unitless
 - Voltage
 - Volume
 - VolumetricFlow
 - Wavenumber

## Arithmetic.

```c#
private static LengthUnit m = LengthUnit.m;
private static TimeUnit s = TimeUnit.s;

[Test]
public void ArithmeticSample()
{
    Length length = 1*m;
    Time time = 2*s;
    Speed speed = length/time;
    Assert.AreEqual(0.5, speed.MetresPerSecond);
}
```


## Conversion.
```c#
[Test]
public void Sample()
{
    var l = Length.FromCentimetres(1.2);
    Assert.AreEqual(0.012, l.Metres);
}
```

## Formatting.
A large number of overloads for `ToString()`

```c#
[Test]
public void FormatSpeed()
{
    var speed = Speed.FromMetresPerSecond(1.2);
    using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
    {
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString());
        Assert.AreEqual("1.20 m/s", speed.ToString("F2 m/s"));
        Assert.AreEqual(UnknownFormat, 1.2.ToString(UnknownFormat)); // for comparison
        Assert.AreEqual(UnknownFormat, speed.ToString(UnknownFormat));
        Assert.AreEqual("F1\u00A0{unit: invalid}", speed.ToString("F1 invalid"));
        Assert.AreEqual("1.20 m⋅s⁻¹", speed.ToString("F2 m⋅s⁻¹"));
        Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString("f1", "m⋅s⁻¹"));
        Assert.AreEqual("1.2 m⋅s⁻¹", speed.ToString("f1 ", "m⋅s⁻¹"));
        Assert.AreEqual("1.2 m⋅s⁻¹", speed.ToString("f1", " m⋅s⁻¹"));
        Assert.AreEqual("1.2  m⋅s⁻¹", speed.ToString("f1 ", " m⋅s⁻¹"));
        Assert.AreEqual("{value: null} mm⋅s⁻¹", speed.ToString("mm⋅s⁻¹"));
        Assert.AreEqual("1200\u00A0s⁻¹⋅mm", speed.ToString("F0", "s⁻¹⋅mm"));
        Assert.AreEqual("1200\u00A0s⁻¹⋅mm¹", speed.ToString("F0", "s⁻¹⋅mm¹"));
        Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString("F1", "m*s^-1"));
        Assert.AreEqual("1.2\u00A0s^-1*m", speed.ToString("F1", "s^-1*m"));
        Assert.AreEqual("1.2\u00A0s^-1*m^1", speed.ToString("F1", "s^-1*m^1"));
        Assert.AreEqual("4.32\u00A0km/h", speed.ToString(SpeedUnit.KilometresPerHour));
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.Default));
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers));
        Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers));
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript));
        Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript));
        Assert.AreEqual("4.3\u00A0km/h", speed.ToString("F1", SpeedUnit.KilometresPerHour));
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.Default));
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers));
        Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers));
        Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript));
        Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript));
        Assert.AreEqual("1,200.00 mm⋅s⁻¹", speed.ToString("N mm⋅s⁻¹"));
    }

    var sv = CultureInfo.GetCultureInfo("sv-SE");

    Assert.AreEqual("1,2\u00A0m/s", speed.ToString(sv));
    Assert.AreEqual("1,20 m/s", speed.ToString("F2 m/s", sv));
    Assert.AreEqual(UnknownFormat, 1.2.ToString(UnknownFormat, sv)); // for comparison
    Assert.AreEqual(UnknownFormat, speed.ToString(UnknownFormat, sv));
    Assert.AreEqual("F1\u00A0{unit: invalid}", speed.ToString("F1 invalid", sv));
    Assert.AreEqual("1,20 m⋅s⁻¹", speed.ToString("F2 m⋅s⁻¹", sv));
    Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString("f1", "m⋅s⁻¹", sv));
    Assert.AreEqual("1,2 m⋅s⁻¹", speed.ToString("f1 ", "m⋅s⁻¹", sv));
    Assert.AreEqual("1,2 m⋅s⁻¹", speed.ToString("f1", " m⋅s⁻¹", sv));
    Assert.AreEqual("1,2  m⋅s⁻¹", speed.ToString("f1 ", " m⋅s⁻¹", sv));
    Assert.AreEqual("{value: null} mm⋅s⁻¹", speed.ToString("mm⋅s⁻¹", sv));
    Assert.AreEqual("1200\u00A0s⁻¹⋅mm", speed.ToString("F0", "s⁻¹⋅mm", sv));
    Assert.AreEqual("1200\u00A0s⁻¹⋅mm¹", speed.ToString("F0", "s⁻¹⋅mm¹", sv));
    Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString("F1", "m*s^-1", sv));
    Assert.AreEqual("1,2\u00A0s^-1*m", speed.ToString("F1", "s^-1*m", sv));
    Assert.AreEqual("1,2\u00A0s^-1*m^1", speed.ToString("F1", "s^-1*m^1", sv));
    Assert.AreEqual("4,32\u00A0km/h", speed.ToString(SpeedUnit.KilometresPerHour, sv));
    Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.Default, sv));
    Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers, sv));
    Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers, sv));
    Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript, sv));
    Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript, sv));
    Assert.AreEqual("4,3\u00A0km/h", speed.ToString("F1", SpeedUnit.KilometresPerHour, sv));
    Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.Default, sv));
    Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers, sv));
    Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers, sv));
    Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript, sv));
    Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript, sv));
    Assert.AreEqual("1\u00A0200,00 mm⋅s⁻¹", speed.ToString("N mm⋅s⁻¹", sv));
}
```
## Parsing.

```c#
[TestCase("1.2m/s")]
[TestCase("1.2m^1/s^1")]
[TestCase("1.2m^1*s^-1")]
[TestCase("1.2m^1*s^-1")]
[TestCase("1.2m⋅s⁻¹")]
[TestCase("1.2m¹/s¹")]
[TestCase("1.2m^1/s¹")]
public void ParsingSample(string text)
{
    var speed = Speed.Parse(text, CultureInfo.InvariantCulture);
    Assert.AreEqual(Speed.FromMetresPerSecond(1.2), Speed.Parse(text));
    Assert.IsTrue(Speed.TryParse(text, CultureInfo.InvariantCulture, out speed));
    Assert.AreEqual(Speed.FromMetresPerSecond(1.2), Speed.Parse(text));
}
```

## WPF.
[![NuGet](https://img.shields.io/nuget/v/Gu.Units.Wpf.svg)](https://www.nuget.org/packages/Gu.Units.Wpf/)

Valueconverters for binding to quantity types.

```xaml
<TextBox Text="{Binding Length, Converter={units:LengthConverter mm}}" />
```

### ValueFormat

Specifies how the scalar part is formatted, formats valid for `double` are valid.
```xaml
Text="{Binding Length,
               Converter={units:LengthConverter cm, ValueFormat='F2'}}" />
```

### SymbolFormat
Specifies how the symbol is formatted.

```xaml
Text="{Binding Speed,
               Converter={units:SpeedConverter mm/s, SymbolFormat=SignedSuperScript}}" />
```

### SymbolFormat
Specifies how the symbol is formatted. The default value is `ScalarOnly`.

```xaml
Text="{Binding Length,
               Converter={units:LengthConverter m, UnitInput=SymbolRequired}}" />
```

## JSON.
[![NuGet](https://img.shields.io/nuget/v/Gu.Units.Json.svg)](https://www.nuget.org/packages/Gu.Units.Json/)

Jsonconverters for serializtion using [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/).

## Code generation when adding new quantities.

For adding new units and quantities read [this](https://github.com/JohanLarsson/Gu.Units/blob/master/Gu.Units.Generator/Templates/Readme.md)

