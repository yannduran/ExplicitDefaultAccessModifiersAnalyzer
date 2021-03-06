﻿using System;
using TestHelper;
using NUnit.Framework;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis;

namespace ExplicitDefaultAccessModifiersAnalyzer.Tests
{
	[TestFixture]
	public class FieldTests : TestsBase
	{
		[Test]
		public void ExplicitPrivateField()
		{
            const string Test = @"
namespace N
{
	class C
	{ 
		private int i;
	}
}";
			const string Fixed = @"
namespace N
{
	class C
	{ 
		int i;
	}
}";
			var expected = new DiagnosticResult
			{
				Id = ExplicitDefaultAccessModifiersAnalyzer.DiagnosticId,
				Severity = DiagnosticSeverity.Warning,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 6, 3)
				}
			};
			VerifyCSharpDiagnostic(Test, expected);
			VerifyCSharpFix(Test, Fixed);
		}

		[Test]
		public void ImplicitPrivateField()
		{
			const string Test = @"
namespace N
{
	class C
	{ 
		int i;
	}
}";
			VerifyCSharpDiagnostic(Test);
		}

		[Test]
		public void ProtectedInternalField()
		{
			const string Test = @"
namespace N
{
	class C
	{ 
		protected internal int i;
	}
}";
			VerifyCSharpDiagnostic(Test);
		}

		[Test]
		public void ExplicitPrivateEvent()
		{
			const string Test = @"
namespace N
{
	class C
	{ 
		private event EventHandler E;
	}
}";
			const string Fixed = @"
namespace N
{
	class C
	{ 
		event EventHandler E;
	}
}";
			var expected = new DiagnosticResult
			{
				Id = ExplicitDefaultAccessModifiersAnalyzer.DiagnosticId,
				Severity = DiagnosticSeverity.Warning,
				Locations = new[]
				{
					new DiagnosticResultLocation("Test0.cs", 6, 3)
				}
			};
			VerifyCSharpDiagnostic(Test, expected);
			VerifyCSharpFix(Test, Fixed);
		}

		[Test]
		public void ImplicitPrivateEvent()
		{
			const string Test = @"
namespace N
{
	class C
	{ 
		event EventHandler E;
	}
}";
			VerifyCSharpDiagnostic(Test);
		}
	}
}