grammar musa; 

musa : (comando)+ EOF;

comando :  (asignacion) | (condicion) | (impresion) | (loopFor) | loopWhile;

loopFor : FOR SEP* SPAR SEP* asignacion SEP* (comp) INSEP 
        SEP* incremento SEP* EPAR
        SBR comando+ EBR #standardFor
        | FOR SEP* SPAR SEP* asignacion SEP* (BOOLEAN) INSEP 
        SEP* incremento SEP* EPAR
        SBR comando+ EBR #booleanFor
;

loopWhile: WHILE SEP* SPAR (comp) EPAR SBR comando+ EBR #conditionWhile
           |
           WHILE SEP* SPAR (BOOLEAN) EPAR SBR comando+ EBR #booleanWhile
           ;

condicion : IF SEP comp SEP+ THEN SEP* SBR 
(comando)+ EBR (else)? ;

incremento: ID SUM EQUAL NUM|ID DIF EQUAL  NUM|ID SUM SUM|ID DIF DIF;

comp : (((ID|NUM) SEP* OP SEP* (ID|NUM)));

else : ELSE SBR (comando)+ EBR ;
impresion : IMP SPAR (SENT|ID) EPAR INSEP
;

asignacion : ID SEP* ASSIGN SEP* expresion SEP* INSEP #int
            | ID ASSIGN SENT #string
           ;

expresion : expresion op=(SUM|DIF) termino #sumORes
          | termino                        #terminoSolo
          ;

termino : termino op=(MULT|DIV) factor #mulODiv
        | factor                      #factorSolo
        ;

factor : NUM                      #numero
       | ID                       #identificador
       | SPAR expresion EPAR      #subexpresion
       ;

FOR : 'for'; 
WHILE : 'while';
IMP : 'monta';
BOOLEAN : 'TRUE' | 'FALSE' | 'true' | 'false' ;
IF : 'if' ;
THEN : 'then' ;
ELSE : 'else' ;
NUM : [0-9]+ ;
SENT : QUOTE (PALABRA|ID)* (SEP (PALABRA|ID))* QUOTE | QUOTE NUM QUOTE ;
PALABRA : NUM | (NUM WORD)+ | (NUM WORD NUM)+; 
ID : ([A-Za-z]+ [0-9]*)+;
WORD : [A-Za-z]+ ;
COMA : ',';
QUOTE : '"';
SUM : '+' ; 
DIF : '-' ;
DIV : '/' ;
MULT : '*' ;
ASSIGN : '<-';
INSEP : ';' ;
SBR : '[' ; 
EBR : ']' ;
SPAR : '(' ;
EPAR : ')' ;
SEP : ' ';
OP : '==' | '>' | '<' | '>=' | '<=' | '<>' ;
EQUAL: '=';




WS : '\n' -> skip ;
SK2 : '\r' -> skip;
SK3 : '    '+ -> skip;