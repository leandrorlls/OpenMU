﻿// <copyright file="PKChatCommandArgs.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlugIns.ChatCommands.Arguments
{
    /// <summary>
    /// Arguments used by PKChatCommandPlugIn.
    /// </summary>
    public class PKChatCommandArgs : ArgumentsBase
    {
        /// <summary>
        /// Gets or sets the character name.
        /// </summary>
        [Argument("character_name")]
        public string? CharacterName { get; set; }

        /// <summary>
        /// Gets or sets the pk level.
        /// </summary>
        [Argument("pk_level")]
        [ValidValues("1", "2", "3")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the pk count.
        /// </summary>
        [Argument("pk_count")]
        public int Count { get; set; }
    }
}
