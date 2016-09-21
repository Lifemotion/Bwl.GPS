#pragma once
#include "board/board.h"

#define LED_DELAY 0
//#define LED_DELAY 3
char digits[16];

char digit_to_code(char src);
void led_send_symbol_code(char code);
void led_lock();
void led_enable(char state);
void led_send_buffer(char* symbols);