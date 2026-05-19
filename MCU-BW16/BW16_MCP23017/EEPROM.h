#ifndef __EEPROM_COMPAT_H
#define __EEPROM_COMPAT_H

#include "Arduino.h"
#include <FlashMemory.h>

class EEPROMClass
{
  public:
    bool begin(unsigned int size);
    byte read(int address);
    void write(int address, byte value);
    bool commit();

  private:
    unsigned int _size = 0;
    bool _begun = false;
};

extern EEPROMClass EEPROM;

#endif
