#ifndef __FADC_H
#define __FADC_H

#include "Timer.h"
#include "Config.h"
#include "Global.h"

extern bool flag_FADC_motorTrigger;
extern bool flag_FADC_lockerTrigger;
extern bool flag_FADC_lokerInput;
extern bool flag_FADC_lokerOutput;
extern bool flag_FADC_buttonInput;
extern bool flag_FADC_motorOutput;

extern int FADC_motorDelayTime;

// 外部函式
void FADC_MotorTrigger();
void FADC_LockerTrigger();
void FADC_LockerInputRead();
void FADC_ButtonInputRead();
#endif
