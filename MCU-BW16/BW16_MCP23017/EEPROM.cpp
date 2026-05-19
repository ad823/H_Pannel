#include "EEPROM.h"

EEPROMClass EEPROM;

bool EEPROMClass::begin(unsigned int size)
{
    if(size == 0) return false;

    if(!_begun || _size != size)
    {
        unsigned int flashSize = 0x1000;
        while(flashSize < size)
        {
            flashSize += 0x1000;
        }
        FlashMemory.begin(FLASH_MEMORY_APP_BASE, flashSize);
        _size = size;
        _begun = true;
    }

    FlashMemory.read();
    return true;
}

byte EEPROMClass::read(int address)
{
    if(!_begun || address < 0 || (unsigned int)address >= _size)
    {
        return 0xFF;
    }
    return FlashMemory.buf[address];
}

void EEPROMClass::write(int address, byte value)
{
    if(!_begun || address < 0 || (unsigned int)address >= _size)
    {
        return;
    }
    FlashMemory.buf[address] = value;
}

bool EEPROMClass::commit()
{
    if(!_begun)
    {
        return false;
    }
    FlashMemory.update();
    return true;
}
