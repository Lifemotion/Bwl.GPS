#pragma once

#include "board/board.h"

volatile unsigned char gps_status1;

volatile unsigned char gps_satellites;
volatile unsigned char gps_quality;

volatile unsigned char gps_hour;
volatile unsigned char gps_min;
volatile unsigned char gps_sec;
volatile unsigned char gps_msec;

volatile signed char gps_timezone;
char gps_location[64];

char gps_decode_gprmc(char* buffer);
char gps_decode_gpgga(char* buffer);

