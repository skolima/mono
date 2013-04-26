//
// System.Web.SysConfigInteroperability.cs - 
//   Unit tests for interoperability between System.Web and ConfigurationManager
//
// Authors:
//	Darrell Mozingo <darrell.mozingo@7digital.com>
//	Andres G. Aragoneses <andres@7digital.com>
//
// Copyright (C) 2013 7digital Media, Ltd (http://www.7digital.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Configuration;
using System.Web;

using NUnit.Framework;

// this single test has this AAAAAA prefix in its namespace to make sure
// it is the very first to run within this test suite,
// otherwise BXC#11972 cannot be reproduced within this test suite
namespace AAAAAAA_MonoTests.System.Web {

	[TestFixture]
	public class SystemConfigurationConfigurationManagerAppSettingsTest
	{
		[Test]
		public void UsageOfSystemWebApiShouldNotBreakAccessToAppSettings()
		{
			Assert.IsNotNull (ConfigurationManager.AppSettings ["BXC11972"], "Null on first try");

			// any API in System.Web seems to expose the bug, i.e. this too: VirtualPathUtility.Combine ("/hi", "there");
			HttpUtility.HtmlEncode ("foo");

			Assert.IsNotNull (ConfigurationManager.AppSettings ["BXC11972"], "Null on second try");
		}
	}
}
