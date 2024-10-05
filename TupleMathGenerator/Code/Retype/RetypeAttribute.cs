namespace TupleMathGenerator.Retype;
using System;

#pragma warning disable CS9113   // Parameter is unread

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class RetypeAttribute(
	string newType,
	RetypeTargets retypeTargets,
	string conversionMethod,
	ConversionTargets conversionTargets)
	: Attribute
{ }