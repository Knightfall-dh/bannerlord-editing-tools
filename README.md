# Bannerlord Editing Tools

## Introduction

A friend and mentor once gave me one of the most valuable pieces of knowledge somebody ever shared with me, he said "make tools, make as many tools as you can to make your job easier and less time consuming". 

This is a module made for all the people suffering from the painful and tedious process that is to edit and create new troops in Mount & Blade Bannerlord.

## Features

I've added three buttons to the inventory screen, `Set/Roster` and `Import`.

`Set/Roster` will create a `EquipmentRoster/EquipmenSet` element with all the items equipped by the character set for the exact slots that each equipement is in and add it to your clipboard so you can past the contents in the troop xml file.

![Copy Set Gif](https://github.com/S-Jakubauskas/bannerlord-editing-tools/blob/main/editingtoolsample.gif)

Please note that Bannerlord mixes character equipment so for every set it is highly advisable to keep the same types in specific slots, for example shields in slot 2. This will prevent troops spawning with two shields, for example.

`Import` does the opposite, it will read your clipboard and equip the main character with the items. It should be useful especially when editing existing troops so you can get a baseline ready without having to search for all pieces of equipment individually.

![Import Set Gif](https://github.com/S-Jakubauskas/bannerlord-editing-tools/blob/main/importequipmentsample.gif)

The way I found to refresh the inventory is by closing and opening the screen again, there might be more efficient ways of doing that and I may look into this in the future, but for now, be adivised that importing sets with cheats enabled could take a second or maybe more depending on how many additional items are available.

## Notes

I was motivated to revive an older and cruder version of this and make it more compatible with other mods as a gesture of appreciation to SinnBadd from the Bannerkings discord, his troops redesign saved my game from freezings caused by OSA assets and as a thank you I wanted to provide people with something that could help them with the hard work that is troop editing.

I would also like to apologise to hunharibo, I had mentioned I had something that could help improving troop editing in a [post in 2021](https://forums.taleworlds.com/index.php?threads/how-do-you-create-troop-troop-trees.446946/#post-9749511). I had offered to share that code but never did.