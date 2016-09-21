#include "shift_led.h"
char digits[16]={};

char digit_to_code(char src)
{
	switch (src)
	{
		case 1: return 32+64; break;
		case 2: return 255-4-32-1; break;
		case 3: return 255-4-8-1; break;
		case 4: return 4+2+64+32; break;
		case 5: return 255-64-8-1; break;
		case 6: return 255-64-1; break;
		case 7: return 128+64+32; break;
		case 8: return 255-1; break;
		case 9: return 255-8-1; break;
		case 0: return 255-2-1; break;
		
		case '1': return 32+64; break;
		case '2': return 255-4-32-1; break;
		case '3': return 255-4-8-1; break;
		case '4': return 4+2+64+32; break;
		case '5': return 255-64-8-1; break;
		case '6': return 255-64-1; break;
		case '7': return 128+64+32; break;
		case '8': return 255-1; break;
		case '9': return 255-8-1; break;
		case '0': return 255-2-1; break;
		
		case '-': return 2; break;
		case '_': return 16; break;
		case '.': return 1; break;
		case 'O': return 255-2-1; break;
		case 'A': return 255-16-1; break;
		case 'B': return 4+8+16+32+2; break;
		case 'C': return 2+8+16; break;
		case 'D': return 64+32+16+8+2; break;
		case 'E': return 255-64-32-1; break;
		case 'F': return 128+4+8+2; break;
		case 'V': return 8+16+32; break;
		case 'U': return 8+16+32+4+64; break;
		case 'S': return 255-64-8-1; break;
		case 'T': return 64+32+128; break;
		case 'L': return 4+8+16; break;
		case 'R': return 2+8; break;
	}
	return 0;
}


void led_send_symbol_code(char code)
{
	setbit (DDRD,5,1);
	setbit (DDRD,6,1);
	char mask=1;
	for (char b=0; b<8; b++)
	{
		if (code&mask) setbit (PORTD,6,1) else setbit (PORTD,6,0);
		mask*=2;
		_delay_us(LED_DELAY);
		setbit (PORTD,5,1);
		_delay_us(LED_DELAY);
		setbit (PORTD,5,0);
		
	}
}

void led_lock()
{
	setbit (DDRD,4,1);
	setbit (PORTD,4,0);
	_delay_us(10);
	setbit (PORTD,4,1);
	_delay_us(10);
	setbit (PORTD,4,0);
}

void led_enable(char state)
{
	/*setbit (DDRC,0,1);
	if (state) setbit (PORTC,0,0) else setbit (PORTC,0,1);*/
}

void led_send_buffer(char* symbols)
{
	led_send_symbol_code(digit_to_code(symbols[3]));
	led_send_symbol_code(digit_to_code(symbols[2]));
	led_send_symbol_code(digit_to_code(symbols[1]));
	led_send_symbol_code(digit_to_code(symbols[0]));
	led_send_symbol_code(digit_to_code(symbols[7]));
	led_send_symbol_code(digit_to_code(symbols[6]));
	led_send_symbol_code(digit_to_code(symbols[5]));
	led_send_symbol_code(digit_to_code(symbols[4]));
	led_send_symbol_code(digit_to_code(symbols[11]));
	led_send_symbol_code(digit_to_code(symbols[10]));
	led_send_symbol_code(digit_to_code(symbols[9]));
	led_send_symbol_code(digit_to_code(symbols[8]));
	led_send_symbol_code(digit_to_code(symbols[15]));
	led_send_symbol_code(digit_to_code(symbols[14]));
	led_send_symbol_code(digit_to_code(symbols[13]));
	led_send_symbol_code(digit_to_code(symbols[12]));	
	led_lock();
}