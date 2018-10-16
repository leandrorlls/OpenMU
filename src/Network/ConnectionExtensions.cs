﻿// <copyright file="ConnectionExtensions.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Network
{
    using System;
    using System.Buffers;

    /// <summary>
    /// Extension methods for <see cref="IConnection"/>.
    /// </summary>
    public static class ConnectionExtensions
    {
        /// <summary>
        /// Sends the specified packet.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="packet">The packet.</param>
        public static void Send(this IConnection connection, ReadOnlySpan<byte> packet)
        {
            lock (connection)
            {
                connection.Output.Write(packet);
                connection.Output.FlushAsync();
            }
        }

        /// <summary>
        /// Starts a safe write to this connection. The specified packet size has to be exact, because it can't be changed afterwards.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="exactPacketSize">Size of the exact packet.</param>
        /// <returns>An <see cref="IDisposable"/> which can be used in a using-construct. It provides the target span to write at, too.</returns>
        public static ThreadSafeWrite SafeWrite(this IConnection connection, int exactPacketSize)
        {
            return new ThreadSafeWrite(connection, exactPacketSize);
        }
    }
}
