using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Console.Tests
{
    public class ConsoleTest
    {
        private const string Message = "message";

        private Console console;
        private MessageWrapper messageWrapper;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            console = ScriptableObject.CreateInstance<Console>();
            messageWrapper = new MessageWrapper(Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLog()
        {
            console.Active = true;
            console.Log(Message);

            LogAssert.Expect(LogType.Log, Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertNoLog()
        {
            console.Active = false;
            console.Log(Message);

            LogAssert.NoUnexpectedReceived();
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLazyLog()
        {
            console.Active = true;
            console.LazyLog(() => messageWrapper.ToString());

            Assert.IsTrue(messageWrapper.WasInvoked);
            LogAssert.Expect(LogType.Log, Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLazyNoLog()
        {
            console.Active = false;
            console.LazyLog(() => messageWrapper.ToString());

            Assert.IsFalse(messageWrapper.WasInvoked);
            LogAssert.NoUnexpectedReceived();
            yield return null;
        }
        
        
        [UnityTest]
        public IEnumerator AssertLogWarning()
        {
            console.Active = true;
            console.Warning(Message);

            LogAssert.Expect(LogType.Warning, Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertNoLogWarning()
        {
            console.Active = false;
            console.Warning(Message);

            LogAssert.NoUnexpectedReceived();
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLazyLogWarning()
        {
            console.Active = true;
            console.LazyWarning(() => messageWrapper.ToString());

            Assert.IsTrue(messageWrapper.WasInvoked);
            LogAssert.Expect(LogType.Warning, Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLazyNoLogWarning()
        {
            console.Active = false;
            console.LazyWarning(() => messageWrapper.ToString());

            Assert.IsFalse(messageWrapper.WasInvoked);
            LogAssert.NoUnexpectedReceived();
            yield return null;
        }
        
        
        [UnityTest]
        public IEnumerator AssertLogError()
        {
            console.Active = true;
            console.Error(Message);

            LogAssert.Expect(LogType.Error, Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertNoLogError()
        {
            console.Active = false;
            console.Error(Message);

            LogAssert.NoUnexpectedReceived();
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLazyLogError()
        {
            console.Active = true;
            console.LazyError(() => messageWrapper.ToString());

            Assert.IsTrue(messageWrapper.WasInvoked);
            LogAssert.Expect(LogType.Error, Message);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertLazyNoLogError()
        {
            console.Active = false;
            console.LazyError(() => messageWrapper.ToString());

            Assert.IsFalse(messageWrapper.WasInvoked);
            LogAssert.NoUnexpectedReceived();
            yield return null;
        }

        private class MessageWrapper
        {
            private readonly string message;
            
            private bool wasInvoked;
            public bool WasInvoked => wasInvoked;

            public MessageWrapper(string message)
            {
                this.message = message;
            }

            public override string ToString()
            {
                wasInvoked = true;
                return message;
            }
        }
    }
}