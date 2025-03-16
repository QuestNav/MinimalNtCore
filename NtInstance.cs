using System;
using System.Text;

namespace MinimalNtCore
{

    public unsafe class NtInstance
    {
        private readonly uint handle;

        public NtInstance(string instanceName)
        {
            handle = NtCoreNatives.NT_GetDefaultInstance();

            byte[] nameUtf8 = Encoding.UTF8.GetBytes(instanceName);

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                NtCoreNatives.NT_StartClient4(handle, &str);
            }
        }

        public void SetTeamNumber(int teamNumber, int port = NtCoreNatives.NT_DEFAULT_PORT4)
        {
            NtCoreNatives.NT_SetServerTeam(handle, (uint)teamNumber, (uint)port);
        }

        public bool IsConnected()
        {
            return NtCoreNatives.NT_IsConnected(handle) != 0;
        }

        public DoubleSubscriber GetDoubleSubscriber(string name, PubSubOptions options)
        {
            byte[] nameUtf8 = Encoding.UTF8.GetBytes(name);

            uint topicHandle;

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                topicHandle = NtCoreNatives.NT_GetTopic(handle, &str);
            }

            byte[] typeStr = Encoding.UTF8.GetBytes("double");

            uint subHandle;
            fixed (byte* ptr = typeStr)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)typeStr.Length,
                };
                NativePubSubOptions nOptions = options.ToNative();
                subHandle = NtCoreNatives.NT_Subscribe(topicHandle, NtType.NT_DOUBLE, &str, &nOptions);
            }
            return new DoubleSubscriber(subHandle);
        }

        public DoublePublisher GetDoublePublisher(string name, PubSubOptions options)
        {
            byte[] nameUtf8 = Encoding.UTF8.GetBytes(name);

            uint topicHandle;

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                topicHandle = NtCoreNatives.NT_GetTopic(handle, &str);
            }

            byte[] typeStr = Encoding.UTF8.GetBytes("double");

            uint subHandle;
            fixed (byte* ptr = typeStr)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)typeStr.Length,
                };
                NativePubSubOptions nOptions = options.ToNative();
                subHandle = NtCoreNatives.NT_Publish(topicHandle, NtType.NT_DOUBLE, &str, &nOptions);
            }
            return new DoublePublisher(subHandle);
        }

        public IntegerPublisher GetIntegerPublisher(string name, PubSubOptions options)
        {
            byte[] nameUtf8 = Encoding.UTF8.GetBytes(name);

            uint topicHandle;

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                topicHandle = NtCoreNatives.NT_GetTopic(handle, &str);
            }

            byte[] typeStr = Encoding.UTF8.GetBytes("int");

            uint subHandle;
            fixed (byte* ptr = typeStr)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)typeStr.Length,
                };
                NativePubSubOptions nOptions = options.ToNative();
                subHandle = NtCoreNatives.NT_Publish(topicHandle, NtType.NT_INTEGER, &str, &nOptions);
            }
            return new IntegerPublisher(subHandle);
        }

        public IntegerSubscriber GetIntegerSubscriber(string name, PubSubOptions options)
        {
            byte[] nameUtf8 = Encoding.UTF8.GetBytes(name);

            uint topicHandle;

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                topicHandle = NtCoreNatives.NT_GetTopic(handle, &str);
            }

            byte[] typeStr = Encoding.UTF8.GetBytes("int");

            uint subHandle;
            fixed (byte* ptr = typeStr)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)typeStr.Length,
                };
                NativePubSubOptions nOptions = options.ToNative();
                subHandle = NtCoreNatives.NT_Subscribe(topicHandle, NtType.NT_INTEGER, &str, &nOptions);
            }
            return new IntegerSubscriber(subHandle);
        }

        public FloatArrayPublisher GetFloatArrayPublisher(string name, PubSubOptions options)
        {
            byte[] nameUtf8 = Encoding.UTF8.GetBytes(name);

            uint topicHandle;

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                topicHandle = NtCoreNatives.NT_GetTopic(handle, &str);
            }

            byte[] typeStr = Encoding.UTF8.GetBytes("float[]");

            uint subHandle;
            fixed (byte* ptr = typeStr)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)typeStr.Length,
                };
                NativePubSubOptions nOptions = options.ToNative();
                subHandle = NtCoreNatives.NT_Publish(topicHandle, NtType.NT_FLOAT_ARRAY, &str, &nOptions);
            }
            return new FloatArrayPublisher(subHandle);
        }

        public FloatArraySubscriber GetFloatArraySubscriber(string name, PubSubOptions options)
        {
            byte[] nameUtf8 = Encoding.UTF8.GetBytes(name);

            uint topicHandle;

            fixed (byte* ptr = nameUtf8)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)nameUtf8.Length,
                };

                topicHandle = NtCoreNatives.NT_GetTopic(handle, &str);
            }

            byte[] typeStr = Encoding.UTF8.GetBytes("float[]");

            uint subHandle;
            fixed (byte* ptr = typeStr)
            {
                WpiString str = new WpiString
                {
                    str = ptr,
                    len = (UIntPtr)typeStr.Length,
                };
                NativePubSubOptions nOptions = options.ToNative();
                subHandle = NtCoreNatives.NT_Subscribe(topicHandle, NtType.NT_FLOAT_ARRAY, &str, &nOptions);
            }
            return new FloatArraySubscriber(subHandle);
        }
    }
}
