namespace TupleMath.Generators.Retype;
using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class RetypeAttribute(
	string newType,
	RetypeTargets retypeTargets,
	string conversionMethod,
	ConversionTargets conversionTargets)
	: Attribute
{ }